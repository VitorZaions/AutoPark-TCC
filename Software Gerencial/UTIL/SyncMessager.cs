using AutoUTIL;
using System;


namespace Utils
{
    public class SyncMessager
    {
        public static DialogResult CreateMessage(int TipoTela, string NomeTela, string Descricao, string Color, bool ButtonCancelarNao, bool ForceDisableOthers)
        {
            return CreateMessageWork(TipoTela, NomeTela, Descricao, Color, ButtonCancelarNao, ForceDisableOthers, false, false);
        }

        private static DialogResult CreateMessageWork(int TipoTela, string NomeTela, string Descricao, string Color, bool ButtonCancelar, bool ForceDisableOthers, bool IsUpdating, bool IsAviso)
        {

            // Tipo Tela - 0 = Confirmar Cancelar, 1 = Sim e Não

            MessageSync Messager = new MessageSync(TipoTela,NomeTela, Descricao, Color, ButtonCancelar, ForceDisableOthers, IsUpdating, IsAviso);
            Messager.Shown += delegate (Object sender, EventArgs e)
            {
                // ((Form)sender).WindowState = FormWindowState.Normal;
                ((Form)sender).Activate();
            };
            //Messager.Activate();
            Messager.ShowDialog();
            return Messager.DialogResult;
        }        
    }
}
