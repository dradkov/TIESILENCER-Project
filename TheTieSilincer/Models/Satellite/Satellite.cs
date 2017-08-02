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
         this.PlayerManager = playerManager;
         this.ShipManager = shipManager;
    }

public event EventHandler SendData2;
    public void StartSendingData()
    {
        this.SendData2(this, EventArgs.Empty);
    }

   
    public PlayerManager PlayerManager
    {
        get
        {
            return playerManager;
        }

        set
        {
            playerManager = value;
        }
    }

    public ShipManager ShipManager
    {
        get
        {
            return shipManager;
        }

        set
        {
            shipManager = value;
        }
    }

    public void ReceiveDataByPlayer(PlayerManager playerManager)
    {
        playerManager.Player.Ship.SendData -= PlayerShipSendCoords;

        playerManager.Player.Ship.SendData += PlayerShipSendCoords;
    }

    public void PlayerShipSendCoords(object sender, EventArgs e)
    {
        

    }

    public void ReceiveDataFromShips(ShipManager shipManager)
    {
        shipManager.SendData -= ShipsSendedCoords;

        shipManager.SendData += ShipsSendedCoords;
    }

    public void ShipsSendedCoords(object sender, EventArgs e)
    {
         

    }

    public void TransmitMessagesFromPlayerToShips(PlayerManager playerManager, ShipManager shipManager)
    {
        if (shipManager.Ships.Count > 0)
        {
            shipManager.ListenPlayerShipCoords(this);

            playerManager.Player.Ship.StartSendingData();

            this.StartSendingData();
        }
    }


    public void TransmitMessagesFromShipsToPlayer(ShipManager shipManager, PlayerManager playerManager)
    {
        if (shipManager.Ships.Count > 0)
        {
            playerManager.Player.Ship.ListenEnemyShipsCoords(this);

            shipManager.StartSendingDataFromEnemyShips();

            this.StartSendingData();
        }
    }


}

