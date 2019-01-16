using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Team02
{
    public class RandomF
    {
        private int BaseNext()
        {
            byte[] randomBytes = new byte[4];
            RNGCryptoServiceProvider rngServiceProvider = new RNGCryptoServiceProvider();
            rngServiceProvider.GetBytes(randomBytes);
            Int32 result = BitConverter.ToInt32(randomBytes, 0);
            if (result == Int32.MaxValue)
                result--;
            return result;
        }
        public virtual int Next()
        {
            return Math.Abs(BaseNext());
        }

        public virtual int Next(int max)
        {
            return (int)(max * NextFloat());
        }

        public virtual int Next(int min, int max)
        {
            return min + (int)((max - min) * NextFloat());
        }

        public virtual double NextDouble()
        {
            return Next() / (double)Int32.MaxValue;
        }

        public virtual double NextDouble(double min, double max)
        {
            double c = max - min;
            return NextDouble() * c + min;
        }

        public virtual float NextFloat()
        {
            return Next() / (float)Int32.MaxValue;
        }

        public virtual float NextFloat(float min, float max)
        {
            float c = max - min;
            return NextFloat() * c + min;
        }
    }
}
