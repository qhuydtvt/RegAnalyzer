using RegAnalyzer.Models;

namespace RegAnalyzer.ViewModels
{
    public class RegisterDataVM
    {
        public RegisterData RegisterData { get; private set; }
        public RegisterDataVM(RegisterData registerData)
        {
            RegisterData = registerData;
        }
    }
}
