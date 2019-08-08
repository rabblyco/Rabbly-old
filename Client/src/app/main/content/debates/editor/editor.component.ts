import { Component, OnInit, OnChanges, Output, EventEmitter } from '@angular/core';
import { EditorContent } from '../../../../models/editor.model';

@Component({
  selector: 'app-editor',
  templateUrl: './editor.component.html',
  styleUrls: ['./editor.component.scss']
})
export class EditorComponent {
  // tslint:disable-next-line:no-output-on-prefix
  @Output() onEditorChanged = new EventEmitter<EditorContent>();

  quillConfig = {
    toolbar: {
      container: [
        ['bold', 'italic', 'underline', 'strike'],        // toggled buttons
        ['code-block'],
        // [{ 'header': 1 }, { 'header': 2 }],               // custom button values
        [{ 'list': 'ordered' }, { 'list': 'bullet' }],
        [{ 'script': 'sub' }, { 'script': 'super' }],      // superscript/subscript
        [{ 'indent': '-1' }, { 'indent': '+1' }],          // outdent/indent
        [{ 'direction': 'rtl' }],                         // text direction
        [{ 'size': ['small', false, 'large', 'huge'] }],  // custom dropdown
        [{ 'header': [1, 2, 3, 4, 5, 6, false] }],
        // [{ 'font': [ 'Oxygen'] }],
        [{ 'align': [] }],
        ['clean'],                                         // remove formatting button
        // ['link'],
        ['link', 'image', 'video'],
        // ['emoji']
      ],
      // handlers: { 'emoji': function () { } }
    },
  };

  html: string;

  constructor() { }

  sendEditorContent(): void {
    const decoded = this.html.replace(/<[^>]*>/g, ' ');

    this.onEditorChanged.emit({ text: decoded , html: this.html });
  }
}
