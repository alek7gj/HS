using NUnit.Framework.Legacy;
using NUnit.Framework;
using System;
using System.Collections;

namespace DemoWebShop.Resources.Helpers
{
    public class BaseHelper
    {
        /// <summary>
        /// Sleep for n seconds.
        /// </summary>
        /// <param name="numsecs"></param>
        public void SleepSeconds(int numsecs)
        {
            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(numsecs));
        }

        /// <summary>
        /// Sleep for n milliseconds.
        /// </summary>     
        /// <param name="milliseconds"></param>
        public void SleepMilliseconds(int milliseconds)
        {
            System.Threading.Thread.Sleep(TimeSpan.FromMilliseconds(milliseconds));
        }
    }
}
