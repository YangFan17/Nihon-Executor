import { Pipe, PipeTransform } from '@angular/core';
import { AppConsts } from '@shared/AppConsts';

@Pipe({ name: 'lengthLimit' })
export class LengthLimitPipe implements PipeTransform {
    transform(value: string, length: number): string {
        if (value) {
            if (value.length > length) {
                return value.substring(0, length) + '...';
            } else {
                return value
            }
        } else {
            return value
        }
    }
}