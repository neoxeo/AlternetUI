#pragma once
#include "Common.h"
#include "Control.h"
#include "ApiTypes.h"
#include "Object.h"
#include "wx/propgrid/propgrid.h"

namespace Alternet::UI
{
    class PropertyGrid : public Control
    {
#include "Api/PropertyGrid.inc"
    public:
        wxWindow* CreateWxWindowCore(wxWindow* parent) override;
        wxPropertyGrid* GetPropGrid();
        PropertyGrid(long styles);

    private:
        long _createStyle = wxPG_DEFAULT_STYLE;

    };
}