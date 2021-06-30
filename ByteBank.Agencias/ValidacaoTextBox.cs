using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace ByteBank.Agencias
{
    public delegate void ValidacaoEventHandler(object sender, ValidacaoEventArgs e);

    public class ValidacaoTextBox : TextBox
    {
        private ValidacaoEventHandler _validacao;
        public event ValidacaoEventHandler Validacao
        {
            add
            {
                _validacao = value;
                OnValidate();

            }
            remove
            {
                _validacao -= value;
            }
        }

        protected override void OnTextChanged(TextChangedEventArgs e)
        {
            base.OnTextChanged(e);
            OnValidate();
        }

        protected virtual void OnValidate()
        {
            if(_validacao != null)
            {
                var listDelegates = _validacao.GetInvocationList();
                var eventArgs = new ValidacaoEventArgs(Text);
                var ehValido = true;

                foreach (var validacao in listDelegates)
                {
                    validacao(this, eventArgs);
                    if(!eventArgs.Ehvalido)
                    {
                        ehValido = false;
                        break;
                    }
                }

                Background = ehValido
                    ? new SolidColorBrush(Colors.White)
                    : new SolidColorBrush(Colors.OrangeRed);
            }
        }
    }
}
