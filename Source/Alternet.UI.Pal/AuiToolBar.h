#pragma once
#include "Common.h"
#include "ApiTypes.h"
#include "Object.h"
#include "Control.h"
#include "ImageSet.h"
#include <wx/aui/aui.h>

namespace Alternet::UI
{
    class AuiToolBar : public Control
    {
#include "Api/AuiToolBar.inc"
    public:
        wxAuiToolBar* GetToolbar();
        AuiToolBar(long styles);
        wxWindow* CreateWxWindowCore(wxWindow* parent) override;
        int _eventToolId = 0;

    private:
        long _createStyle = wxAUI_TB_DEFAULT_STYLE;
        void FromEventData(wxAuiToolBarEvent& event);
        void OnToolDropDown(wxAuiToolBarEvent& event);
        void OnBeginDrag(wxAuiToolBarEvent& event);
        void OnMiddleClick(wxAuiToolBarEvent& event);
        void OnOverflowClick(wxAuiToolBarEvent& event);
        void OnRightClick(wxAuiToolBarEvent& event);
    };
}
