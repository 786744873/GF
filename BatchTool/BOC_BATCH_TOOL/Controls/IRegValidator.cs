using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using BOC_BATCH_TOOL.EnumTypes;
using BOC_BATCH_TOOL.Types;

namespace BOC_BATCH_TOOL.Controls
{
    public interface IRegValidator
    {
        EditorValidateRule ValidateRule { get; set; }

        bool ValidateEnabled { get; set; }

        ErrorProvider ErrorProvider { get; set; }

        string TranslateValidationMessage();

        bool EditorValueChanged { get; set; }

        bool ShowRequiredFlag { get; }

        void UpdateAttach();
    }
}
