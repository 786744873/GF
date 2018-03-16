using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using CommonClient.Controls;
using CommonClient.SysCoach;
using CommonClient.Types;

namespace CommonClient.Entities
{
    public class NameValueObject
    {
        public int Value { get; set; }
        public string Name { get; set; }
    }

    [Flags]
    public enum ValidateErrorType
    {
        [TranslatingKey("", "校验通过", "", "")]
        Succeed = 1,

        [TranslatingKey("", "必填项为空", "", "")]
        RequiredButEmpty = 2,

        [TranslatingKey("", "比要求的输入长度短", "", "")]
        ShorterThanRequired = 4,

        [TranslatingKey("", "比要求的输入长度长", "", "")]
        LongerThanRequired = 8,

        [TranslatingKey("", "遇到非法字符", "", "")]
        IllegealCharactersMet = 16
    }

    [Serializable]
    public class EntityBase
    {
        // 根据正则，必填，最小长度，最大长度校验字段值是否合法
        public bool CheckValueIsValid(string fieldValue, string regValue, bool required, int minLength, int maxLength)
        {
            var regex = new Regex(regValue);
            var textLength = string.IsNullOrEmpty(fieldValue) ? 0 : System.Text.Encoding.UTF8.GetBytes(fieldValue).Length;
            var isValid = (((string.IsNullOrEmpty(fieldValue) && !required)) ? true : regex.IsMatch(fieldValue)) && ((required ? (!string.IsNullOrEmpty(fieldValue) && required) : true) && (textLength >= minLength) && (textLength <= maxLength));
            return isValid;
        }

        public ValidationResult CheckValueIsValid2(string fieldValue, string regValue, bool required, int minLength, int maxLength)
        {
            var result = new ValidationResult { FieldValue = fieldValue };

            if (!string.IsNullOrEmpty(fieldValue))
            {
                var regex = new Regex(regValue);
                if (!regex.IsMatch(fieldValue))
                {
                    var list = new List<char>();
                    foreach (char c in fieldValue)
                    {
                        var cString = c.ToString();
                        var isMatch = regex.IsMatch(cString);
                        if (!isMatch && !list.Contains(c))
                        {
                            list.Add(c);
                            result.ValidationDetail = result.ValidationDetail | ValidateErrorType.IllegealCharactersMet;
                        }
                    }
                    foreach (char c in list)
                    {
                        result.Message += string.Format(" {0} ", c);
                    }
                }

                if (fieldValue.Length > maxLength)
                {
                    result.ValidationDetail = result.ValidationDetail | ValidateErrorType.LongerThanRequired;
                    result.Message = string.Format("{0} {1}", fieldValue.Length, maxLength);
                }
                else if (fieldValue.Length < minLength)
                {
                    result.ValidationDetail = result.ValidationDetail | ValidateErrorType.ShorterThanRequired;
                    result.Message = string.Format("{0} {1}", fieldValue.Length, minLength);
                }
            }

            if (string.IsNullOrEmpty(fieldValue))
            {
                result.ValidationDetail = result.ValidationDetail | ValidateErrorType.RequiredButEmpty;
            }

            return result;
        }

        // 用特的的 DvValidatRuleAttribute 校验具体实体具体字段的值是否合法
        public ValidationResult CheckEntityFieldByRuleAttribute(string fieldName, DvValidatRuleAttribute ruleAttribute)
        {
            var xType = this.GetType();
            foreach (PropertyInfo propertyInfo in xType.GetProperties())
            {
                if (string.Equals(propertyInfo.Name, fieldName, StringComparison.CurrentCultureIgnoreCase))
                {
                    var regValue = ValidatorList.GetRegValueByCode(ruleAttribute.RegCode);
                    var fieldObjectValue = propertyInfo.GetValue(this, null);
                    var validationResult = CheckValueIsValid2(fieldObjectValue as string, regValue, ruleAttribute.Required, ruleAttribute.MinLength, ruleAttribute.MaxLength);
                    validationResult.FieldName = fieldName;
                    return validationResult;
                }
            }
            return null;
        }

        // 用特定的 DvValidatRuleAttribute 校验具体实体具体字段的值是否合法
        public ValidationResult CheckEntityFieldByRuleAttribute(string fieldName, string ruleAttributeName)
        {
            var xType = this.GetType();
            foreach (PropertyInfo propertyInfo in xType.GetProperties())
            {
                if (string.Equals(propertyInfo.Name, fieldName, StringComparison.CurrentCultureIgnoreCase))
                {
                    var ruleAttribute = GetEntityFieldRuleAttribute(fieldName, ruleAttributeName);
                    var regValue = ValidatorList.GetRegValueByCode(ruleAttribute.RegCode);
                    var fieldObjectValue = propertyInfo.GetValue(this, null);
                    var validationResult = CheckValueIsValid2(fieldObjectValue as string, regValue, ruleAttribute.Required, ruleAttribute.MinLength, ruleAttribute.MaxLength);
                    validationResult.FieldName = fieldName;
                    return validationResult;
                }
            }
            return null;
        }

        public ValidationResults CheckStandardEntity()
        {
            var totalResults = new ValidationResults { Pass = true };

            var xType = this.GetType();
            foreach (PropertyInfo propertyInfo in xType.GetProperties())
            {
                var fieldObjectValue = propertyInfo.GetValue(this, null);
                var fieldStringValue = fieldObjectValue == null ? string.Empty : fieldObjectValue.ToString();
                var dvRuleCustomAttributes = propertyInfo.GetCustomAttributes(typeof(DvValidatRuleAttribute), false);
                if (dvRuleCustomAttributes.Length == 1) // 只有一个注入配置项时，做普通检查
                {
                    var ruleAttribute = dvRuleCustomAttributes[0] as DvValidatRuleAttribute;
                    if (ruleAttribute != null)
                    {
                        var regValue = ValidatorList.GetRegValueByCode(ruleAttribute.RegCode);
                        var validationResult = CheckValueIsValid2(fieldStringValue, regValue, ruleAttribute.Required, ruleAttribute.MinLength, ruleAttribute.MaxLength);
                        validationResult.FieldName = propertyInfo.Name;
                        if (!validationResult.Pass)
                        {
                            totalResults.Results.Add(validationResult);
                            totalResults.Pass = false;
                        }
                    }
                }
            }
            return totalResults;
        }

        public DvValidatRuleAttribute GetEntityFieldRuleAttribute(string fieldName, string ruleAttributeName)
        {
            var xType = this.GetType();
            foreach (PropertyInfo propertyInfo in xType.GetProperties())
            {
                if (string.Equals(fieldName, propertyInfo.Name, StringComparison.CurrentCultureIgnoreCase))
                {
                    var dvRuleCustomAttributes = propertyInfo.GetCustomAttributes(typeof(DvValidatRuleAttribute), false);
                    foreach (DvValidatRuleAttribute dvRuleCustomAttribute in dvRuleCustomAttributes)
                    {
                        if (string.Equals(dvRuleCustomAttribute.CaseDescription, ruleAttributeName, StringComparison.CurrentCultureIgnoreCase))
                            return dvRuleCustomAttribute;
                    }
                }
            }
            return null;
        }

    }

}
