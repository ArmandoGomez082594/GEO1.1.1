using System;


namespace GEO1.1.1.Infraestructure
{
   using ViewModels;
public class InstanceLocator
{
    #region Propiedades
    public MainViewModels  Main
    {
        get;
        set;
    }
    #endregion
    #region Constructores
    public InstanceLocator()
    {
        this.Main = new MainViewModels();
    }

    #endregion
}
}
