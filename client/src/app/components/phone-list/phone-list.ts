import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { PhoneModel } from '../../models/phone-model';

@Component({
  selector: 'app-phone-list',
  imports: [CommonModule],
  templateUrl: './phone-list.html',
  styleUrl: './phone-list.scss'
})
export class PhoneList {
  @Input() phones: PhoneModel[] = [];
  @Output() edit = new EventEmitter<PhoneModel>();
  @Output() delete = new EventEmitter<string>();
}
