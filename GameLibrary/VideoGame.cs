namespace GameLibrary;

public class VideoGame : Game
    {
        public class Device
        {
            public string Name { get; protected set; }
            public Device(string name)
            {
                Name = name;
            }
            public static Device SMARTPHONE = new Device("smartphone");
            public static Device COMPUTER = new Device("computer");
            public static Device VR = new Device("vr headset");
        }
        public int Layers { get; protected set; }
        public ISet<Device> Devices { get; protected set; } = new SortedSet<Device>();
        public override void Init()
        {
            Console.WriteLine("Input paramethers of video game:");
            base.Init();
            Console.WriteLine("Input devices:");
            Devices = new SortedSet<Device>(Input.InputList().Select(name => new Device(name)));
            Console.WriteLine("Input count of layers:");
            Layers = Input.InputNoLess(1);
        }
        public override void RandomInit()
        {
            base.RandomInit();
            Devices = new SortedSet<Device>();
            switch (Rand.rand.Next (0,2))
            {
                case 0: 
                    Devices.Add(Device.SMARTPHONE);
                    break;
                case 1:
                    Devices.Add(Device.COMPUTER);
                    break;
                default:
                    Devices.Add(Device.COMPUTER);
                    Devices.Add(Device.SMARTPHONE);
                    break;
            }
            Layers = Rand.rand.Next(1, 20);
        }
        public new string StringProperties()
        {
            return base.StringProperties()+$", devices: {string.Join(", ", Devices.Select(s => s.Name))}";
        }
        public override void Show()
        {
            Console.WriteLine($"Video geme({StringProperties()})");
        }
    }
