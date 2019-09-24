using System;


namespace GEO1.1.1.ViewModels
{
    public class MainViewModels
        {
    #region ViewModels
    public LoginViewModel Login
    {
        get;
        set;
    }

    public GEOViewModel GEO
    {
        get;
        set;
    }
    #endregion
    #region Constructors
    public MainViewModels()
    {
        instance = this;
        this.Login = new LoginViewModel();
    }
    #endregion
    #region Singleton
    private static MainViewModels instance;
    public static MainViewModels Getinstance()
        {
        if (instance == null)
        {
            return new MainViewModels();
        }
        return instance;
        }
    #endregion
}
}
