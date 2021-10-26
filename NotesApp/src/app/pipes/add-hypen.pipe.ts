import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'addHypen'
})
export class AddHypenPipe implements PipeTransform {

  transform(value: string, charAdd: string): string {

    value = charAdd + value + charAdd;
    return value;
  }

}
