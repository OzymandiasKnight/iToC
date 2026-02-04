using System.Windows.Controls;
using System;

namespace Archivum
{
	public partial class InputLine : UserControl
	{
		public InputLine()
		{
			InitializeComponent();
			this.DataContext = this;
			InputLineLabel.Foreground = PaletteSystem.text;
			InputLineText.Background = PaletteSystem.background;
			InputLineText.Foreground = PaletteSystem.text;
		}

		public string LabelText { get; set; }

		//Numeric only property
		private bool _isNumeric;
		public bool IsNumeric {
			get => _isNumeric;
			set {
				_isNumeric = value;
			}
		}

		//New value check
		private bool _isUpdate;
		private string _textValue; 
		public string TextValue {
			get => _textValue;
			set {
				if (_isNumeric) {
					int number;
					if (int.TryParse(value, out number)) {
						_textValue = value;
					}
				}
				else {
					_textValue = value;
				}

				if (!_isUpdate) {
					_isUpdate = true;
					if (InputLineText.Text != _textValue) {
						int pos = InputLineText.CaretIndex;
						InputLineText.Text = _textValue;
						InputLineText.CaretIndex = pos;
					}
					_isUpdate = false;
				}
			}
		}

		//Default value
		private string _defaultValue;
		public string DefaultValue {
			get => _defaultValue;
			set {
				_defaultValue = value;
				TextValue = value;
			}
		}
		//Text Changed Event
		private void textChanged(object sender, TextChangedEventArgs e) {
			if (!_isUpdate) {
				TextValue = InputLineText.Text;
			}
		}
	}
}
