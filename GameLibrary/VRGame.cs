namespace GameLibrary;

public class VRGame : VideoGame
    {
        public VRGame()
        {
            Devices.Add(VideoGame.Device.VR);
        }

        public override void Init()
        {
            Console.WriteLine("Input paramethers of vr game:");
            base.Init();
            Devices.Add(VideoGame.Device.VR);
        }
        public override void RandomInit()
        {
            base.RandomInit();
            Devices = new SortedSet<VideoGame.Device>();
            Devices.Add(VideoGame.Device.VR);
        }
        public override void Show()
        {
            Console.WriteLine($"VR game({StringProperties()})");
        }

    }