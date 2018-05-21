/**
 * @license Copyright (c) 2003-2015, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see LICENSE.md or http://ckeditor.com/license
 */

CKEDITOR.editorConfig = function (config) {
    // Define changes to default configuration here. For example:
    config.language = 'vi';
    config.fullPage = false; /*<html><body></body></html> ahihi do ngoc ngech*/
    config.skin = 'office2013';
    config.height = '600px';
    config.allowedContent = true;
    // config.uiColor = '#AADC6E';

    //tich hop ckfinder vao ckeditor
  

        config.filebrowserBrowseUrl = '/ckfinder/ckfinder.html';
        config.filebrowserImageBrowseUrl = '/ckfinder/ckfinder.html?Type=Images';
        config.filebrowserFlashBrowseUrl = '/ckfinder/ckfinder.html?Type=Flash';
        config.filebrowserUploadUrl = '/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files';
        config.filebrowserImageUploadUrl = '/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Images';
        config.filebrowserFlashUploadUrl = '/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash';

        config.pasteFromWordRemoveFontStyles = false;
        config.pasteFromWordRemoveStyles = false;
        config.enterMode = CKEDITOR.ENTER_BR;
        config.shiftEnterMode = CKEDITOR.ENTER_P;
    //plug
        config.extraPlugins = 'timestamp,strinsert';
      

   
};
CKEDITOR.config.allowedContent = true;
CKEDITOR.plugins.add('timestamp', {
    icons: 'timestamp',
    init: function (editor) {
        editor.addCommand('insertTimestamp', {
            exec: function (editor) {
                var now = new Date();
                editor.insertHtml('The current date and time is: <em>' + now.toString() + '</em>');
            }
        });
        editor.ui.addButton('Timestamp', {
            label: 'Insert Timestamp',
            command: 'insertTimestamp',
            toolbar: 'insert'
        });
    }
});


CKEDITOR.plugins.add('strinsert',
{
    requires: ['richcombo'],
    init: function (editor) {
        //  array of strings to choose from that'll be inserted into the editor
        var strings = [];
        strings.push(['{hihi}', 'FAQs', 'FAQs']);
        strings.push(['{socute}', 'Glossary', 'Glossary']);
        strings.push(['{youngxi}', 'Career Courses', 'Career Courses']);
        strings.push(['{adubi}', 'Career Profiles', 'Career Profiles']);

        // add the menu to the editor
        editor.ui.addRichCombo('strinsert',
		{
		    label: 'Insert Content',
		    title: 'Insert Content',
		    voiceLabel: 'Insert Content',
		    className: 'cke_format',
		    multiSelect: false,
		    panel:
			{
			    css: [editor.config.contentsCss, CKEDITOR.skin.getPath('editor')],
			    voiceLabel: editor.lang.panelVoiceLabel
			},

		    init: function () {
		        this.startGroup("Insert Content");
		        for (var i in strings) {
		            this.add(strings[i][0], strings[i][1], strings[i][2]);
		        }
		    },

		    onClick: function (value) {
		        editor.focus();
		        editor.fire('saveSnapshot');
		        editor.insertHtml(value);
		        editor.fire('saveSnapshot');
		    }
		});
    }
});