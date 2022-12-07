using System.Threading;
using System.Windows.Forms;

namespace PDV.UTIL
{
    public class LoadingCall
    {
        private LoadingScreen.Loading LoadingScreen;
        private string _Texto;
        public LoadingCall(string Texto)
        {
            _Texto = Texto;
        }

        public void ShowLoading()
        {
            ShowLoadingWork();
        }

        private void ShowLoadingWork()
        {
            Thread LoadingThread = new Thread(() =>
            {
                LoadingScreen = new LoadingScreen.Loading(_Texto);
                Application.Run(LoadingScreen);
            });
            LoadingThread.Start();
        }

        public void CloseLoading()
        {
            CloseLoadingWork();
        }

        private void CloseLoadingWork()
        {
            bool IsNull = true;
            while (IsNull)
            {
                if (LoadingScreen == null)
                    continue;

                if (LoadingScreen.IsHandleCreated == false)
                    continue;

                if (LoadingScreen.Visible == false)
                    continue;

                IsNull = false;
                LoadingScreen?.Invoke((MethodInvoker)(() => { LoadingScreen.Finish(); LoadingScreen.Close(); }));
            }
        }
    }
}
