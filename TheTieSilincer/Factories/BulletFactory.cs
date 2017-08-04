using System;
using System.Linq;
using System.Reflection;
using TheTieSilincer.Enums;
using TheTieSilincer.Models;
using TheTieSilincer.Models.Bullets;

namespace TheTieSilincer.Factories
{
    public class BulletFactory
    {
        public Bullet CreateBullet(BulletType bulletType, Position position)
        {
            Type typeOfBullet = Assembly.GetExecutingAssembly().GetTypes().
                FirstOrDefault(v => v.Name == bulletType.ToString());

            Bullet bullet = (Bullet)Activator.CreateInstance(typeOfBullet, position);

            return bullet;


        }
    }
}
