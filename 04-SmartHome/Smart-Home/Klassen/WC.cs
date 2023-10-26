﻿namespace Smart_Home.Klassen
{
	class WC : Raum, IHeizungsventil
	{
		public WC(int temperatur = 20, int personen = 0) : base(temperatur, personen)
		{
		}
		private bool _Heizt { get; set; }
		bool IHeizungsventil.Heizt { get { return _Heizt; } }
		public void CheckHeizung(Wettersensor.Wetterdaten daten)
		{
			if (daten.Temperatur < Temperatur)
			{
				if (!_Heizt)
				{
					Console.WriteLine($"Dieser Raum(id={Id}) wird geheizt");
					_Heizt = true;
				}
			}
			else
			{
				if (_Heizt)//Hat zuvor geheizt, hört jetzt auf
				{
					Console.WriteLine($"Dieser Raum(id={Id}) wird nicht mehr geheizt");
					_Heizt = false;
				}
			}
		}
	}
}