﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alternet.UI.Localization;

namespace Alternet.UI
{
    /// <summary>
    /// Implements main control of the Find and Replace dialogs.
    /// </summary>
    public class FindReplaceControl : GenericToolBarSet
    {
        private readonly TextBox findEdit = new()
        {
            Margin = (2, 0, 2, 0),
        };

        private readonly TextBox replaceEdit = new()
        {
            Margin = (2, 0, 2, 0),
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="FindReplaceControl"/> class.
        /// </summary>
        public FindReplaceControl()
        {
            ToolBarCount = 3;

            OptionsToolBar.AddPicture(null);

            IdMatchCase = OptionsToolBar.AddStickyBtn(
                CommonStrings.Default.FindOptionMatchCase,
                OptionsToolBar.GetNormalSvgImages().ImgFindMatchCase,
                OptionsToolBar.GetDisabledSvgImages().ImgFindMatchCase,
                null,
                OnClickMatchCase);
            OptionsToolBar.SetToolShortcut(IdMatchCase, KnownKeys.FindReplaceControlKeys.MatchCase);

            IdMatchWholeWord = OptionsToolBar.AddStickyBtn(
                CommonStrings.Default.FindOptionMatchWholeWord,
                OptionsToolBar.GetNormalSvgImages().ImgFindMatchFullWord,
                OptionsToolBar.GetDisabledSvgImages().ImgFindMatchFullWord,
                null,
                OnClickMatchWholeWord);
            OptionsToolBar.SetToolShortcut(IdMatchWholeWord, KnownKeys.FindReplaceControlKeys.MatchWholeWord);

            IdUseRegularExpressions = OptionsToolBar.AddStickyBtn(
                CommonStrings.Default.FindOptionUseRegularExpressions,
                OptionsToolBar.GetNormalSvgImages().ImgRegularExpr,
                OptionsToolBar.GetDisabledSvgImages().ImgRegularExpr,
                null,
                OnClickUseRegularExpressions);
            OptionsToolBar.SetToolShortcut(IdUseRegularExpressions, KnownKeys.FindReplaceControlKeys.UseRegularExpressions);

            IdToggleReplaceOptions = FindToolBar.AddSpeedBtn(
                CommonStrings.Default.ToggleToSwitchBetweenFindReplace,
                FindToolBar.GetNormalSvgImages().ImgAngleDown,
                FindToolBar.GetDisabledSvgImages().ImgAngleDown);

            findEdit.SuggestedWidth = 150;
            findEdit.EmptyTextHint = CommonStrings.Default.ButtonFind;
            replaceEdit.EmptyTextHint = CommonStrings.Default.ButtonReplace;
            replaceEdit.SuggestedWidth = 150;
            IdFindEdit = FindToolBar.AddControl(findEdit);

            IdFindNext = FindToolBar.AddSpeedBtn(
                CommonStrings.Default.ButtonFindNext,
                FindToolBar.GetNormalSvgImages().ImgArrowDown,
                FindToolBar.GetDisabledSvgImages().ImgArrowDown);
            FindToolBar.SetToolShortcut(IdFindNext, KnownKeys.FindReplaceControlKeys.FindNext);

            IdFindPrevious = FindToolBar.AddSpeedBtn(
                CommonStrings.Default.ButtonFindPrevious,
                FindToolBar.GetNormalSvgImages().ImgArrowUp,
                FindToolBar.GetDisabledSvgImages().ImgArrowUp);
            FindToolBar.SetToolShortcut(IdFindPrevious, KnownKeys.FindReplaceControlKeys.FindPrevious);

            IdFindClose = FindToolBar.AddSpeedBtn(
                CommonStrings.Default.ButtonClose,
                FindToolBar.GetNormalSvgImages().ImgCancel,
                FindToolBar.GetDisabledSvgImages().ImgCancel);

            FindToolBar.Parent = this;

            ReplaceToolBar.AddPicture(null);

            IdReplaceEdit = ReplaceToolBar.AddControl(replaceEdit);

            IdReplace = ReplaceToolBar.AddSpeedBtn(
                CommonStrings.Default.ButtonReplace,
                FindToolBar.GetNormalSvgImages().ImgReplace,
                FindToolBar.GetDisabledSvgImages().ImgReplace);
            ReplaceToolBar.SetToolShortcut(IdReplace, KnownKeys.FindReplaceControlKeys.Replace);

            IdReplaceAll = ReplaceToolBar.AddSpeedBtn(
                CommonStrings.Default.ButtonReplaceAll,
                FindToolBar.GetNormalSvgImages().ImgReplaceAll,
                FindToolBar.GetDisabledSvgImages().ImgReplaceAll);
            ReplaceToolBar.SetToolShortcut(IdReplaceAll, KnownKeys.FindReplaceControlKeys.ReplaceAll);

            ReplaceToolBar.Visible = false;
            ReplaceToolBar.Parent = this;

            FindToolBar.AddToolAction(IdFindNext, OnClickFindNext);
            FindToolBar.AddToolAction(IdFindPrevious, OnClickFindPrevious);
            FindToolBar.AddToolAction(IdFindClose, OnClickClose);
            FindToolBar.AddToolAction(IdToggleReplaceOptions, OnClickToggleReplace);

            ReplaceToolBar.AddToolAction(IdReplace, OnClickReplace);
            ReplaceToolBar.AddToolAction(IdReplaceAll, OnClickReplaceAll);
        }

        /// <summary>
        /// Occurs when 'Find Next' button is clicked.
        /// </summary>
        public event EventHandler? ClickFindNext;

        /// <summary>
        /// Occurs when 'Find Previous' button is clicked.
        /// </summary>
        public event EventHandler? ClickFindPrevious;

        /// <summary>
        /// Occurs when 'Replace' button is clicked.
        /// </summary>
        public event EventHandler? ClickReplace;

        /// <summary>
        /// Occurs when 'Replace All' button is clicked.
        /// </summary>
        public event EventHandler? ClickReplaceAll;

        /// <summary>
        /// Occurs when 'Close' button is clicked.
        /// </summary>
        public event EventHandler? ClickClose;

        /// <summary>
        /// Occurs when option 'Match Case' is changed.
        /// </summary>
        public event EventHandler? OptionMatchCaseChanged;

        /// <summary>
        /// Occurs when option 'Match Whole Word' is changed.
        /// </summary>
        public event EventHandler? OptionMatchWholeWordChanged;

        /// <summary>
        /// Occurs when option 'Use Regular Expressions' is changed.
        /// </summary>
        public event EventHandler? OptionUseRegularExpressionsChanged;

        /// <summary>
        /// Gets or sets 'Match Case' option.
        /// </summary>
        public bool OptionMatchCase
        {
            get
            {
                return OptionsToolBar.GetToolSticky(IdMatchCase);
            }

            set
            {
                if (OptionMatchCase == value)
                    return;
                OptionsToolBar.SetToolSticky(IdMatchCase, value);
                OptionMatchCaseChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Gets or sets 'Match Whole Word' option.
        /// </summary>
        public bool OptionMatchWholeWord
        {
            get
            {
                return OptionsToolBar.GetToolSticky(IdMatchWholeWord);
            }

            set
            {
                if (OptionMatchWholeWord == value)
                    return;
                OptionsToolBar.SetToolSticky(IdMatchWholeWord, value);
                OptionMatchWholeWordChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Gets or sets 'Use Regular Expressions' option.
        /// </summary>
        public bool OptionUseRegularExpressions
        {
            get
            {
                return OptionsToolBar.GetToolSticky(IdUseRegularExpressions);
            }

            set
            {
                if (OptionUseRegularExpressions == value)
                    return;
                OptionsToolBar.SetToolSticky(IdUseRegularExpressions, value);
                OptionUseRegularExpressionsChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Gets id of the 'Match Case' button.
        /// </summary>
        [Browsable(false)]
        public ObjectUniqueId IdMatchCase { get; }

        /// <summary>
        /// Gets id of the 'Match Whole Word' button.
        /// </summary>
        [Browsable(false)]
        public ObjectUniqueId IdMatchWholeWord { get; }

        /// <summary>
        /// Gets id of the 'Use Regular Expressions' button.
        /// </summary>
        [Browsable(false)]
        public ObjectUniqueId IdUseRegularExpressions { get; }

        /// <summary>
        /// Gets id of the 'Toggle Replace Options' button.
        /// </summary>
        [Browsable(false)]
        public ObjectUniqueId IdToggleReplaceOptions { get; }

        /// <summary>
        /// Gets id of the 'Find' editor.
        /// </summary>
        [Browsable(false)]
        public ObjectUniqueId IdFindEdit { get; }

        /// <summary>
        /// Gets id of the 'Replace' editor.
        /// </summary>
        [Browsable(false)]
        public ObjectUniqueId IdReplaceEdit { get; }

        /// <summary>
        /// Gets id of the 'Find Next' button.
        /// </summary>
        [Browsable(false)]
        public ObjectUniqueId IdFindNext { get; }

        /// <summary>
        /// Gets id of the 'Find Previous' button.
        /// </summary>
        [Browsable(false)]
        public ObjectUniqueId IdFindPrevious { get; }

        /// <summary>
        /// Gets id of the 'Close' button.
        /// </summary>
        [Browsable(false)]
        public ObjectUniqueId IdFindClose { get; }

        /// <summary>
        /// Gets id of the 'Replace' button.
        /// </summary>
        [Browsable(false)]
        public ObjectUniqueId IdReplace { get; }

        /// <summary>
        /// Gets id of the 'Replace All' button.
        /// </summary>
        [Browsable(false)]
        public ObjectUniqueId IdReplaceAll { get; }

        /// <summary>
        /// Gets <see cref="TextBox"/> which allows to specify text to find.
        /// </summary>
        [Browsable(false)]
        public TextBox FindEdit => findEdit;

        /// <summary>
        /// Gets <see cref="TextBox"/> which allows to specify text to replace.
        /// </summary>
        [Browsable(false)]
        public TextBox ReplaceEdit => replaceEdit;

        /// <summary>
        /// Gets <see cref="GenericToolBar"/> with find buttons.
        /// </summary>
        [Browsable(false)]
        public GenericToolBar FindToolBar => GetToolBar(0);

        /// <summary>
        /// Gets <see cref="GenericToolBar"/> with replace buttons.
        /// </summary>
        [Browsable(false)]
        public GenericToolBar ReplaceToolBar => GetToolBar(1);

        /// <summary>
        /// Gets <see cref="GenericToolBar"/> with option buttons.
        /// </summary>
        [Browsable(false)]
        public GenericToolBar OptionsToolBar => GetToolBar(2);

        /// <summary>
        /// Gets or sets width of <see cref="FindEdit"/> and <see cref="ReplaceEdit"/>
        /// controls.
        /// </summary>
        public double TextBoxWidth
        {
            get
            {
                return findEdit.SuggestedWidth;
            }

            set
            {
                if (TextBoxWidth == value)
                    return;
                findEdit.SuggestedWidth = value;
                replaceEdit.SuggestedWidth = value;
            }
        }

        /// <summary>
        /// Gets or sets whether <see cref="ReplaceToolBar"/> is visible.
        /// </summary>
        public bool ReplaceVisible
        {
            get
            {
                return ReplaceToolBar.Visible;
            }

            set
            {
                if (value)
                {
                    ReplaceToolBar.Visible = true;
                    FindToolBar.SetToolDisabledImage(
                        IdToggleReplaceOptions,
                        FindToolBar.GetDisabledSvgImages().ImgAngleUp);
                    FindToolBar.SetToolImage(
                        IdToggleReplaceOptions,
                        FindToolBar.GetNormalSvgImages().ImgAngleUp);
                }
                else
                {
                    ReplaceToolBar.Visible = false;
                    FindToolBar.SetToolDisabledImage(
                        IdToggleReplaceOptions,
                        FindToolBar.GetDisabledSvgImages().ImgAngleDown);
                    FindToolBar.SetToolImage(
                        IdToggleReplaceOptions,
                        FindToolBar.GetNormalSvgImages().ImgAngleDown);
                }
            }
        }

        private void OnClickUseRegularExpressions(object? sender, EventArgs e)
        {
            OptionUseRegularExpressions = !OptionUseRegularExpressions;
        }

        private void OnClickMatchWholeWord(object? sender, EventArgs e)
        {
            OptionMatchWholeWord = !OptionMatchWholeWord;
        }

        private void OnClickMatchCase(object? sender, EventArgs e)
        {
            OptionMatchCase = !OptionMatchCase;
        }

        private void OnClickFindNext(object? sender, EventArgs e)
        {
            ClickFindNext?.Invoke(this, e);
        }

        private void OnClickToggleReplace(object? sender, EventArgs e)
        {
            ReplaceVisible = !ReplaceVisible;
        }

        private void OnClickFindPrevious(object? sender, EventArgs e)
        {
            ClickFindPrevious?.Invoke(this, e);
        }

        private void OnClickReplace(object? sender, EventArgs e)
        {
            ClickReplace?.Invoke(this, e);
        }

        private void OnClickReplaceAll(object? sender, EventArgs e)
        {
            ClickReplaceAll?.Invoke(this, e);
        }

        private void OnClickClose(object? sender, EventArgs e)
        {
            ClickClose?.Invoke(this, e);
        }
    }
}