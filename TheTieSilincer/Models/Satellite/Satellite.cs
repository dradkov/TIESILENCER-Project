using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TheTieSilincer.Core;
using TheTieSilincer.Models;
using TheTieSilincer.Models.Ships;

public class Satellite
{

    public Satellite()
    {
        this.position = new Position(0, 0);
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

    public void ReceiveDataByPlayer(PlayerManager playerManager)
    {
        playerManager.Player.Ship.SendData -= PlayerShipSendCoords;

        playerManager.Player.Ship.SendData += PlayerShipSendCoords;
    }

    public void PlayerShipSendCoords(object sender, EventArgs e)
    {
        this.position = ((PlayerShip)sender).Position;

    }

    public void TransmitMessages(PlayerManager playerManager, ShipManager shipManager)
    {
        if (shipManager.Ships.Count > 0)
        {
            shipManager.ListenPlayerShipCoords(this);

            playerManager.Player.Ship.StartSendingData();

            this.StartSendingData();
        }


    }
}

