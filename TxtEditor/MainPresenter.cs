using System; 
using TxtEditorBL;
using MessageService;

namespace TxtEditor
{
    class MainPresenter
    {
        private readonly IMainForm _mainForm;
        private readonly IFileManager _fileManager;
        private readonly IMessageService _messageService;

        private string _currentFilePath;

        public MainPresenter(IMainForm mainForm, IFileManager fileManager, IMessageService messageService)
        {
            _mainForm = mainForm;
            _fileManager = fileManager;
            _messageService = messageService;

            _mainForm.SetSymbolCount(0);
            _mainForm.FileSaveClick += _mainForm_FileSaveClick;
            _mainForm.FileOpenClick += _mainForm_FileOpenClick;
            _mainForm.ContentChanged += _mainForm_ContentChanged;
            
        }

        private void _mainForm_FileSaveClick(object sender, System.EventArgs e)
        {
            try
            {
                string content = _mainForm.Content;
                _fileManager.SaveContent(content, _currentFilePath);
                _messageService.ShowMessage("File completely saved");
            }
            catch(Exception ex)
            {
                _messageService.ShowError(ex.Message);
            }
        }

        private void _mainForm_FileOpenClick(object sender, System.EventArgs e)
        {
            try
            {
                string filePath = _mainForm.FilePath;
                bool isExist = _fileManager.IsExist(filePath);

                if(!isExist)
                {
                    _messageService.ShowExclamation("Selected file not exist");
                    return;
                }

                _currentFilePath = filePath;
                string content = _fileManager.GetContent(filePath);
                int count = _fileManager.GetSymbolCount(content);
                _mainForm.Content = content;
                _mainForm.SetSymbolCount(count);
            }
            catch(Exception ex)
            {
                _messageService.ShowError(ex.Message);
            }
        }

        private void _mainForm_ContentChanged(object sender, System.EventArgs e)
        {
            string content = _mainForm.Content;
            int count = _fileManager.GetSymbolCount(content);
            _mainForm.SetSymbolCount(count);
        }
    }
}