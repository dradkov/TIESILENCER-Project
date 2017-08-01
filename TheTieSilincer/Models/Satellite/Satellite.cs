using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TheTieSilincer.Models;
using TheTieSilincer.Models.Ships;

public class Satellite
{

    public Satellite()
    {
        this.position = new Position(0,0);
    }
    public event EventHandler SendData2;
    public void StartSendingData()
    {
        this.SendData2(this, EventArgs.Empty);
    }

    private Position position;

    public Position Position
    {
        get
        {
            return position;
        }

        set
        {
            position = value;
        }
    }

    public void ReceiveDataByPlayer(PlayerShip playerShip)
    {
        playerShip.SendData -= PlayerShipSendCoords;

        playerShip.SendData += PlayerShipSendCoords;
    }

    public void PlayerShipSendCoords(object sender, EventArgs e)
    {
        this.position = ((PlayerShip)sender).Position;

       // this.StartSendingData();
    }
}

