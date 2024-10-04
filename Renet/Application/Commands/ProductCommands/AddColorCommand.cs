using Infrastructure;

namespace Application.Commands.ProductCommands {
    public class AddColorCommand : CommandBase
    {
        public string Name { get;  set; }
        public string HexCode { get;  set; }
    }
}
