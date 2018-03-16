using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CommonClient.Controls
{
    public interface IDataValidateControl
    {
        Label DvLinkedLabel { get; set; }
        string DvDataField { get; set; }
        int TabIndex { get; set; }
        bool DesignMode { get; }
        ErrorProvider DvErrorProvider { get; set; }
    }

    public interface IDataValidateEditor : IDataValidateControl  // For ComboBox, Text ...
    {
        bool DvRequired { get; set; }
        int DvMinLength { get; set; }
        int DvMaxLength { get; set; }
        ValidatorList DvValidator { get; set; }
        string DvRegCode { get; set; }
        string DvRegValue { get; }
        string DvRegDescription { get; }
        bool DvValidateEnabled { get; set; }
        string DvTranslateValidationMessage();
        bool DvEditorValueChanged { get; set; }
        void DvUpdateAttach();
        void DvUpdateErrorFrame();
        object DvDataValue { get; set; }
        bool DvValidatePassed { get; }
        bool DvFixLength { get; set; }
        RequiredFlagStyle DvRequiredFlagStyle { get; set; }
        bool ManualValidate();
    }

    public interface IDataValidateButton : IDataValidateControl // For RadioButton, CheckBox ...
    {
        int DvDataValue { get; set; }
        bool Checked { get; set; }
    }

    public class DvValidatorRuleItem
    {
        public bool DvRequired { get; set; }
        public int DvMinLength { get; set; }
        public int DvMaxLength { get; set; }
        public bool DvValidateEnabled { get; set; }
    }


    public enum RequiredFlagStyle
    {
        Left = 0,
        Right = 1,
        Bottom = 2,
        Around = 3
    }


}
