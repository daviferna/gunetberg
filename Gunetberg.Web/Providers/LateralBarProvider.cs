using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gunetberg.Web.Providers
{
    public class LateralBarProvider
    {
        public bool IsOpen { get; set; }

        public event EventHandler<bool> OnIsOpenChanged;

        public void Toggle()
        {
            IsOpen = !IsOpen;
            OnIsOpenChanged?.Invoke(this, IsOpen);
        }

        public void Close()
        {
            IsOpen = false;
            OnIsOpenChanged?.Invoke(this, IsOpen);

        }
    }
}
