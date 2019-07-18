import { PipeTransform, Pipe, Injectable } from '@angular/core';

@Pipe({
  name: 'titleCase'
})
@Injectable({ providedIn: 'root' })
export class TitleCasePipe implements PipeTransform {

  transform(value: string, args?: any): any {
    if (!value) {
      return '';
    }

    value = value.toLowerCase();

    var words = value.split(' ');

    for (let i = 0; i < words.length; i++) {
      words[i] = words[i].charAt(0).toUpperCase() + words[i].slice(1);
    }

    return words.join(' ');
  }
}
