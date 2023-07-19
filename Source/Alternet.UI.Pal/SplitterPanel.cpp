#include "SplitterPanel.h"

namespace Alternet::UI
{
	SplitterPanel::SplitterPanel(long styles)
	{
		_styles = styles;
	}

	SplitterPanel::SplitterPanel()
	{

	}

	SplitterPanel::~SplitterPanel()
	{
		if (IsWxWindowCreated())
		{
			auto window = GetWxWindow();
			if (window != nullptr)
			{
				/*window->Unbind(wxEVT_DATE_CHANGED, 
				&DateTimePicker::OnDateTimePickerValueChanged, this);*/
				/*window->Unbind(wxEVT_TIME_CHANGED, 
				&DateTimePicker::OnDateTimePickerValueChanged, this);*/
			}
		}
	}

	wxSplitterWindow* SplitterPanel::GetSplitterWindow()
	{
		return dynamic_cast<wxSplitterWindow*>(GetWxWindow());
	}

	wxWindow* SplitterPanel::CreateWxWindowCore(wxWindow* parent) 
	{
		long styles = GetStyles();

		wxWindow* value = nullptr;

		value = new wxSplitterWindow(
			parent,
			wxID_ANY,
			wxDefaultPosition,
			wxDefaultSize,
			styles);
		
		/*value->Bind(wxEVT_DATE_CHANGED,
			&DateTimePicker::OnDateTimePickerValueChanged, this);*/
		return value;
	}

	int64_t SplitterPanel::GetStyles() 
	{
		return _styles;
	}

	void SplitterPanel::SetStyles(int64_t value)
	{
		if (_styles == value)
			return;
		_styles = value;
		RecreateWxWindowIfNeeded();
	}

	int SplitterPanel::GetMinimumPaneSize()
	{
		return GetSplitterWindow()->GetMinimumPaneSize();
	}

	void SplitterPanel::SetMinimumPaneSize(int value)
	{
		GetSplitterWindow()->SetMinimumPaneSize(value);
	}

	double SplitterPanel::GetSashGravity()
	{
		return GetSplitterWindow()->GetSashGravity();
	}

	void SplitterPanel::SetSashGravity(double value)
	{
		GetSplitterWindow()->SetSashGravity(value);
	}

	int SplitterPanel::GetSashSize()
	{
		return GetSplitterWindow()->GetSashSize();
	}

	void SplitterPanel::SetSashSize(int value)
	{
		//GetSplitterWindow()->SetSashSize(value);
	}

	int SplitterPanel::GetSplitMode()
	{
		return GetSplitterWindow()->GetSplitMode();
	}

	void SplitterPanel::SetSplitMode(int value)
	{
		GetSplitterWindow()->SetSplitMode(value);
	}

	bool SplitterPanel::GetSashVisible()
	{
		return !GetSplitterWindow()->IsSashInvisible();
	}

	void SplitterPanel::SetSashVisible(bool value)
	{
		GetSplitterWindow()->SetSashInvisible(!value);
	}

	bool SplitterPanel::GetIsSplit()
	{
		return GetSplitterWindow()->IsSplit();
	}

	int SplitterPanel::GetSashPosition()
	{
		return GetSplitterWindow()->GetSashPosition();
	}

	void SplitterPanel::SetSashPosition(int value)
	{
		GetSplitterWindow()->SetSashPosition(value, GetRedrawOnSashPosition());
	}

	bool SplitterPanel::GetRedrawOnSashPosition()
	{
		return _redrawOnSashPosition;
	}

	void SplitterPanel::SetRedrawOnSashPosition(bool value)
	{
		_redrawOnSashPosition = value;
	}

	int SplitterPanel::GetDefaultSashSize()
	{
		return GetSplitterWindow()->GetDefaultSashSize();
	}

	Control* SplitterPanel::GetControl1()
	{
		return nullptr;
	}

	Control* SplitterPanel::GetControl2()
	{
		return nullptr;
	}

	/*static*/ void* SplitterPanel::CreateEx(int64_t styles)
	{
		return new SplitterPanel(styles);
	}

	void SplitterPanel::Initialize(Control* window)
	{
		GetSplitterWindow()->Initialize(window->GetWxWindow());
	}

	bool SplitterPanel::Replace(Control* winOld, Control* winNew)
	{
		return GetSplitterWindow()->ReplaceWindow(winOld->GetWxWindow(),
			winNew->GetWxWindow());
	}

	bool SplitterPanel::SplitHorizontally(Control* window1, Control* window2, 
		int sashPosition)
	{
		return GetSplitterWindow()->SplitHorizontally(window1->GetWxWindow(),
			window2->GetWxWindow(), sashPosition);
	}

	bool SplitterPanel::SplitVertically(Control* window1, Control* window2, 
		int sashPosition)
	{
		return GetSplitterWindow()->SplitVertically(window1->GetWxWindow(),
			window2->GetWxWindow(), sashPosition);
	}

	bool SplitterPanel::DoUnsplit(Control* toRemove)
	{
		return GetSplitterWindow()->Unsplit(toRemove->GetWxWindow());
	}

	void SplitterPanel::UpdateSize()
	{
		GetSplitterWindow()->UpdateSize();
	}

}
