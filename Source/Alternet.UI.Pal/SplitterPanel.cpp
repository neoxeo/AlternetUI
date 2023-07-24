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
				window->Unbind(wxEVT_SPLITTER_SASH_POS_CHANGED,
					&SplitterPanel::OnSplitterSashPosChanged, this);
				window->Unbind(wxEVT_SPLITTER_SASH_POS_CHANGING,
					&SplitterPanel::OnSplitterSashPosChanging, this);
				window->Unbind(wxEVT_SPLITTER_SASH_POS_RESIZE,
					&SplitterPanel::OnSplitterSashPosResize, this);
				window->Unbind(wxEVT_SPLITTER_DOUBLECLICKED,
					&SplitterPanel::OnSplitterDoubleClicked, this);
				window->Unbind(wxEVT_SPLITTER_UNSPLIT,
					&SplitterPanel::OnSplitterUnsplit, this);
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

		value->Bind(wxEVT_SPLITTER_SASH_POS_CHANGED,
			&SplitterPanel::OnSplitterSashPosChanged, this);
		value->Bind(wxEVT_SPLITTER_SASH_POS_CHANGING,
			&SplitterPanel::OnSplitterSashPosChanging, this);
		value->Bind(wxEVT_SPLITTER_SASH_POS_RESIZE,
			&SplitterPanel::OnSplitterSashPosResize, this);
		value->Bind(wxEVT_SPLITTER_DOUBLECLICKED,
			&SplitterPanel::OnSplitterDoubleClicked, this);
		value->Bind(wxEVT_SPLITTER_UNSPLIT,
			&SplitterPanel::OnSplitterUnsplit, this);
		return value;
	}

	void SplitterPanel::ToEventData(wxSplitterEvent& event)
	{
		auto eventType = event.GetEventType();

		if (eventType == wxEVT_SPLITTER_SASH_POS_CHANGED
			|| eventType == wxEVT_SPLITTER_SASH_POS_CHANGING
			|| eventType == wxEVT_SPLITTER_SASH_POS_RESIZE)
		_eventData.SashPosition = event.GetSashPosition();

		if (eventType == wxEVT_SPLITTER_SASH_POS_RESIZE) 
		{
			_eventData.OldSize = event.GetOldSize();
			_eventData.NewSize = event.GetNewSize();
		}

		if (eventType == wxEVT_SPLITTER_DOUBLECLICKED)
		{
			_eventData.X = event.GetX();
			_eventData.Y = event.GetY();
		}
	}

	void SplitterPanel::FromEventData(wxSplitterEvent& event)
	{
		auto eventType = event.GetEventType();

		if (eventType == wxEVT_SPLITTER_SASH_POS_CHANGED
			|| eventType == wxEVT_SPLITTER_SASH_POS_CHANGING
			|| eventType == wxEVT_SPLITTER_SASH_POS_RESIZE)
			event.SetSashPosition(_eventData.SashPosition);

		if (eventType == wxEVT_SPLITTER_SASH_POS_RESIZE)
			event.SetSize(_eventData.OldSize, _eventData.NewSize);
	}

	void SplitterPanel::OnSplitterSashPosChanged(wxSplitterEvent& event)
	{
		ToEventData(event);
		RaiseEvent(SplitterPanelEvent::SplitterSashPosChanged);
		FromEventData(event);
	}

	void SplitterPanel::OnSplitterSashPosChanging(wxSplitterEvent& event)
	{
		ToEventData(event);
		RaiseEventEx(SplitterPanelEvent::SplitterSashPosChanging, event, true);
		FromEventData(event);
		if (!_canMoveSplitter)
			event.Veto();
	}

	void SplitterPanel::RaiseEventEx(SplitterPanelEvent eventId, 
		wxSplitterEvent& event, bool canVeto)
	{
		if (canVeto)
		{
			auto result = RaiseEventWithPointerResult(eventId, &_eventData);

			if (result != 0)
				event.Veto();
		}
		else
			RaiseEvent(eventId, &_eventData);
	}
	
	bool SplitterPanel::GetCanMoveSplitter()
	{
		return _canMoveSplitter;
	}

	void SplitterPanel::SetCanMoveSplitter(bool value) 
	{
		_canMoveSplitter = value;
	}

	bool SplitterPanel::GetCanDoubleClick() 
	{
		return _canDoubleClick;
	}

	void SplitterPanel::SetCanDoubleClick(bool value)
	{
		_canDoubleClick = value;
	}

	void SplitterPanel::OnSplitterSashPosResize(wxSplitterEvent& event)
	{
		ToEventData(event);
		bool c = RaiseEvent(SplitterPanelEvent::SplitterSashPosResize);
		FromEventData(event);
		if (c)
			event.Veto();
	}

	void SplitterPanel::OnSplitterDoubleClicked(wxSplitterEvent& event)
	{
		ToEventData(event);
		bool c = RaiseEvent(SplitterPanelEvent::SplitterDoubleClick);
		FromEventData(event);
		if (c || !_canDoubleClick)
			event.Veto();
	}

	void SplitterPanel::OnSplitterUnsplit(wxSplitterEvent& event)
	{
		ToEventData(event);
		bool c = RaiseEvent(SplitterPanelEvent::Unsplit);
		FromEventData(event);
		if (c)
			event.Veto();
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
		auto wx1 = window1->GetWxWindow();
		auto wx2 = window2->GetWxWindow();
		auto result = GetSplitterWindow()->SplitHorizontally(wx1, wx2, sashPosition);
		return result;
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
