using System;

namespace Core.Services.Updater
{
    public interface IProjectUpdater
    {
        event Action UpdateCalled;
        event Action FixedUpdatedCalled;
        event Action LateUpdateCalled;
    }
}