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

    public event EventHandler SendData;
    public void StartSendingData()
    {
        this.SendData(this, EventArgs.Empty);
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

    public void ReceiveDataByPlayer()
    {
        playerManager.SendData -= PlayerShipSendCoords;

        playerManager.SendData += PlayerShipSendCoords;
    }

    public void PlayerShipSendCoords(object sender, EventArgs e)
    {


    }

    public void ReceiveDataFromShips()
    {
        shipManager.SendData -= ShipsSendedCoords;

        shipManager.SendData += ShipsSendedCoords;
    }

    public void ShipsSendedCoords(object sender, EventArgs e)
    {


    }

    private void TransmitMessagesFromPlayerToShips()
    {
        if (shipManager.Ships.Count > 0)
        {
            shipManager.ListenPlayerShipCoords(this);

            playerManager.StartSendingData();

            this.StartSendingData();
        }
    }

    private void TransmitMessagesFromShipsToPlayer()
    {
        if (shipManager.Ships.Count > 0)
        {
            playerManager.ListenEnemyShipsCoords(this);

            shipManager.StartSendingDataFromEnemyShips();

            this.StartSendingData();
        }
    }

    public void TransmitMessages()
    {
        TransmitMessagesFromPlayerToShips();
        TransmitMessagesFromShipsToPlayer();
    }


}

