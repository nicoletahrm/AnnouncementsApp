import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'preposition',
})
export class PrepositionPipe implements PipeTransform {
  transform(value: string): string {
    return 'By ' + value;
  }
}
