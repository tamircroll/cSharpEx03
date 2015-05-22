namespace Ex03.GarageLogic.Vehicles
{
     public class ElectricCar : Car
     {
         private const float k_MaxBattery = 2.2f;
         private readonly Electric r_ElectricEngine;

         public ElectricCar(string i_Model, string i_PlateNumber, eColor i_Color, eNumOfDoors i_NumOfDoors, Wheel i_Wheel, float i_RemainBatteryTime)
             : base(i_Model, i_PlateNumber, i_Wheel, i_Color, i_NumOfDoors)
         {
             r_ElectricEngine = new Electric(i_RemainBatteryTime, k_MaxBattery);
         }

         public float RemainBatteryTime()
         {
             return r_ElectricEngine.RemainBatteryTime;
         }

         public float MaxBattery()
         {
             return r_ElectricEngine.MaxBattery;
         }

         public void ChargeBattery(float i_ToCharge)
         {
             r_ElectricEngine.ChargeBattery(i_ToCharge);
         }

         public override float PercentOfEnergyLeft()
         {
             return RemainBatteryTime()/MaxBattery();
         }

         protected override void SetIsElectric()
         {
             m_IsElectric = true;
         }

         public override string ToString()
         {
             return string.Format(
 @"{0}
{1}
",
 base.ToString(),
 
 r_ElectricEngine);
         }
     }
}