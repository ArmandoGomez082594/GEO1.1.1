using System;
using System.ComponentModel;
using System.Windows.Input;

namespace GEO1.1.1.ViewModels
{
  using GalaSoft.MvvmLight.Command;
using System.Net.Http;

using Xamarin.Forms;

public class LoginViewModel: BaseViewModel
        {
    #region Attributes
    private string email;
    private string password;
    private bool isRunning;
    private bool isEnabled;
    #endregion
    #region Properties
    public string Email
    {
        get { return this.email; }
        set { SetValue(ref this.email, value); }
    }
    public string Password
    {
        get { return this.password; }

        set { SetValue(ref this.password, value); }
    }

    public bool IsRunning
    {
        get { return this.isRunning; }
        set { SetValue(ref this.isRunning, value); }
    }
    public bool IsRemembered
    {
        get;
        set;
    }

    public bool IsEnabled
    {
        get { return this.isEnabled; }
        set { SetValue(ref this.isEnabled, value); }
    }
    #endregion
    #region Constructors
    public LoginViewModel()
    {
        this.IsRemembered = true;
        this.IsEnabled = true;
    }
    #endregion

    #region Commands
        public ICommand LoginCommand
            {
        get
        {
            return new RelayCommand(Login);
        }
            }

        private async void Login()
            {
        if (String.IsNullOrEmpty(this.Email))
        {
            await Application.Current.MainPage.DisplayAlert(
                "Error",
                "Debes ingresar un Correo",
                "Aceptar");
            return;
        }
        if (String.IsNullOrEmpty(this.Password))
        {
            await Application.Current.MainPage.DisplayAlert(
                "Error",
                "Debes ingresar la contraseña",
                "Aceptar");
            return;
        }
        this.IsRunning = true;
        this.IsEnabled = false;
        ////  HttpClient client = new HttpClient();
        //  client.BaseAddress = new Uri("http://localhost:58044/API/login");
        //  string url = string.Format("           {0} {1}", Email, Password);
        //  var response = await client.GetAsync(url);
        //  var result = response.Content.ReadAsStringAsync().Result;
        var multiContent = new StringContent("");

        var _acceso = new Access();

        var O = new Objetos();

        O.Contrasena = Password;
        O.Correo = Email;
        _acceso.multiContent(O, ref multiContent);

        var rutaSincronizacion = "http://localhost:58044/API/login";


        var result = await _acceso.Post(rutaSincronizacion, multiContent);


        var result = await _acceso.Post(rutaSincronizacion, multiContent);

        if (string.IsNullOrEmpty (result) || result ("null"))
        {
            this.IsRunning = false;
            this.IsEnabled = true;
            await Application.Current.MainPage.DisplayAlert(
               "Error",
               "Correo o contraseña invalidos",
               "Aceptar");
            this.Password = string.Empty;
            return;
        }
        
        this.IsRunning = false;
        this.IsEnabled = true;

        this.Email = string.Empty;
        this.Password = string.Empty;

        MainViewModels.Getinstance().GEO = new GEOViewModel();
        await Application.Current.MainPage.Navigation.PushAsync(new GEOPage());
            }
    #endregion
}
}

