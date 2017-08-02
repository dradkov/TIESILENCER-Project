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
    private PlayerManager playerManager;
    private ShipManager shipManager;

    public Satellite(PlayerManager playerManager, ShipManager shipManager)
    {
        this.playerManager = playerManager;
        this.shipManager = shipManager;
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

    public void ReceiveDataByPlayer()
    {
        this.playerManager.Player.Ship.SendData -= PlayerShipSendCoords;

        this.playerManager.Player.Ship.SendData += PlayerShipSendCoords;
    }

    public void PlayerShipSendCoords(object sender, EventArgs e)
    {
        this.position = ((PlayerShip)sender).Position;

       // this.StartSendingData();
    }

    public void TransmitMessages()
    {
        if (shipManager.Ships.Count > 0)
        {
            foreach (var ship in this.shipManager.Ships)
            {
                if (ship.GetType() == typeof(KamikazeShip))
                    (ship as KamikazeShip).ListenPlayerShipCoords(this);
            }

            this.playerManager.Player.Ship.StartSendingData();
            StartSendingData();

        }
    }
}

