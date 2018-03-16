/**
 * @license Copyright (c) 2003-2014, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see LICENSE.md or http://ckeditor.com/license
 */

CKEDITOR.editorConfig = function (config) {
    config.language = 'zh-cn';
    config.font_names = '宋体/宋体;黑体/黑体;仿宋/仿宋_GB2312;楷体/楷体_GB2312;隶书/隶书;幼圆/幼圆;微软雅黑/微软雅黑;' + config.font_names;
	// Define changes to default configuration here. For example:
    config.height = 400;
    //UI边框颜色
    //config.uiColor = '#35aa47';
    config.toolbar = 'MyToolbar';
    config.toolbar_MyToolbar =
    [
    { name: 'document', items: ['NewPage', 'Preview'] },
    { name: 'basicstyles', items: ['Bold', 'Italic', 'Strike'] },
    { name: 'editing', items: ['Find', 'Replace', 'SelectAll'] },
    { name: 'styles', items: ['Styles', 'Format', 'Font', 'FontSize'] },
    { name: 'TextColor', items: ['BGColor'] },
    { name: 'paragraph', items: ['NumberedList', 'BulletedList', 'Outdent', 'Indent'] },
    {  name: 'insert', items: ['Image', 'Table','Smiley', 'HorizontalRule', 'SpecialChar', 'PageBreak'] },
    { name: 'tools', items: ['Maximize'] }
    ];
    config.font_defaultLabel = '微软雅黑';
    config.fontSize_defaultLabel = '14';
};
