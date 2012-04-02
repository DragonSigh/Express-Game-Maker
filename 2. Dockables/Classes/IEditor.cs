/* -----------------------------
 * IEditor
 * -----------------------------
 * Purpose:             Inherited interface by Editors and used by Memontos to refresh the Editor during Undo/Redo.
 * Most Used By:        Editors, Mementos.cs
 * Associated Files:    None
 * Modify:              If you want to add a new Editor function to be inherited and implemented (An interface contains only the signatures of methods, delegates or events. The implementation of the methods is done in the class that implements the interface).
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EGMGame.Library;

namespace EGMGame.Library
{
    public interface IEditor
    {
        void SetupList();
    }
}
