using System;
namespace SQliteMAUI.Services
{
	/// <summary>
	/// ejemplo de patrón Singleton
	/// crea una sola instancia para toda
	/// la aplicación
	/// </summary>
	public class SampleSingleton
	{
		private static SampleSingleton _instance;

		//tenemos que tener un constructor privado
		//para que sola la misma clase
		//se pueda instanciar a traves
		//del metodo statico
		private SampleSingleton() { }


		/// <summary>
		/// necesitamos un metodo estatico
		/// para crear la instancia
		/// dentro de la misma clase
		/// previniendo creaciones externas.
		/// </summary>
		/// <returns></returns>
        public static SampleSingleton GetInstance()
		{
			if (_instance == null)
			{
				_instance = new SampleSingleton();
            }

			return _instance;
        }
    }
}

