import { Component, Input, Output, EventEmitter } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { PhoneModel } from '../../models/phone-model';

@Component({
  selector: 'app-phone-form',
  imports: [FormsModule],
  templateUrl: './phone-form.html',
  styleUrl: './phone-form.scss'
})
export class PhoneForm {
  @Input() phone: PhoneModel = {  number: '', name: '' };
  @Output() save = new EventEmitter<PhoneModel>();
  @Output() cancel = new EventEmitter<void>();

  onSubmit() {
    this.save.emit(this.phone);
  }
}
