// Author: Vlad Untu/Asterix Software
// For updates: http://www.asterixsoft.ro/dyn/open/treeview_filter/

using System;
using System.Collections.Generic;
using System.Text;

namespace EGMGame.Controls
{
    public interface INodeItemsFilter {
        TreeNodeEx[] GetItems(string query);
    }
}
