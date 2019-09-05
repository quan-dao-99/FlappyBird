﻿using UnityEngine;

public interface IPlayerMovementController
{
    Vector2 Position { get; set; }
    float JumpForce { get; set; }
    float MaxHeight { get; set; }
}