
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MidiToKeyboard.App.Tools
{
    public static class AppTools
    {
        public static void Commit(Action action) => Application.Current.Dispatcher.Invoke(action);
        public static async Task CommitAsync(Func<Task> task) =>await Application.Current.Dispatcher.InvokeAsync(task);
    }
}
