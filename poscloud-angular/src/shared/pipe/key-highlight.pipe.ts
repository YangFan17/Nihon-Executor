import { Pipe, PipeTransform } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';

@Pipe({ name: 'keyHighlight' })
export class KeyHighlightPipe implements PipeTransform {
    constructor(private sanitizer: DomSanitizer) {
    }
    transform(value: string, key: string): any {
        if (!key) {
            return value;
        }
        let index = value.indexOf(key);

        if (index == -1) {
            return value;
        }

        let res = value.substring(0, index - 1)
            + '<span class="font-highlight">' + key + '</span>'
            + value.substring(index + key.length);
        //alert(res)
        return res;//this.sanitizer.bypassSecurityTrustHtml(res);
    }
}