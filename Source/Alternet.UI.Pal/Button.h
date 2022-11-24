#pragma once

#include "Common.h"
#include "Control.h"

namespace Alternet::UI
{
    class Button : public Control
    {
#include "Api/Button.inc"
    public:
        wxWindow* CreateWxWindowCore(wxWindow* parent) override;
        void OnButtonClick(wxCommandEvent& event);

        void RaiseClick();

    protected:
        virtual void OnWxWindowCreated() override;
        virtual void OnParentChanged() override;
        virtual void OnAnyParentChanged() override;

    private:
        wxButton* GetButton();

        DelayedValue<Button, string> _text;

        string RetrieveText();
        void ApplyText(const string& value);

        bool _isDefault = false;
        bool _isCancel = false;

        void ApplyIsDefault();
        void ApplyIsCancel();
    };
}
