using GameDemo;
using Godot;
using System;

public partial class SteamRunner : Node
{
  public static INetworkingRepo NetworkingRepo { get; private set; } = null!;

  private SteamPlatformService _platformService = null!;

  public override void _Ready() {
    _platformService = new SteamPlatformService();
    NetworkingRepo = new NetworkingRepo(_platformService);

    _platformService.Init();
  }

  public override void _Process(double delta) {
    _platformService.Tick();
  }

  public override void _ExitTree() {
    NetworkingRepo.Dispose();
    _platformService.Shutdown();
  }
}
