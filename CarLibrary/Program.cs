using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarLibrary
{
    public enum EngineState
    {engineAlive, engineDead }

    public enum MusicMedia
    {
        musicCd,
        musicTape,
        musicRadio,
        musicMp3
    }

    public abstract class Car
    {
        public string PetName { get; set; }
        public int CurrentSpeed { get; set; }
        public int MaxSpeed { get; set; }
        public bool MusicOn { get; set; }

        protected EngineState engState = EngineState.engineAlive;
        protected bool musicOn = true;

        public EngineState EngineState
        {
            get { return engState; }
        }

        public abstract void TurboBoost();
        public Car() {}
        public Car(string name, int maxSp, int currSp)
        {
            PetName = name; MaxSpeed = maxSp; CurrentSpeed = currSp;
        }

        public void TurnOnRadio(MusicMedia mm)
        {
            if (musicOn)
                MessageBox.Show(string.Format("Jumming {0}", mm));
            else
                Console.WriteLine("No music");
        }


    }
}
