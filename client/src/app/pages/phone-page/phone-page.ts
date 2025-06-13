import { Component } from '@angular/core';
import { PhoneForm } from '../../components/phone-form/phone-form';
import { PhoneList } from '../../components/phone-list/phone-list';
import { PhoneModel } from '../../models/phone-model';
import { PhoneService } from '../../services/phone-service';

@Component({
  selector: 'app-phone-page',
  imports: [PhoneForm,PhoneList],
  templateUrl: './phone-page.html',
  styleUrl: './phone-page.scss'
})
export class PhonePage {
  phones: PhoneModel[] = [];
  selectedPhone: PhoneModel = { number: '', name: '' };
  editing = false;

  constructor(private service: PhoneService) {
    this.loadphones();
  }

  loadphones(): void {
    this.service.getAll().subscribe(data => this.phones = data);
  }

  startAdd() {
    this.selectedPhone = { number: '', name: '' };
    this.editing = true;
  }

  onEdit(phone: PhoneModel) {
    this.selectedPhone = { ...phone };
    this.editing = true;
  }

  onSave(phone: PhoneModel) {
    if (phone.id) {
      this.service.update(phone.id, phone).subscribe(() => this.loadphones());
    } else {
      this.service.create(phone).subscribe(() => this.loadphones());
    }
    this.editing = false;
  }

  onDelete(id: string) {
    this.service.delete(id).subscribe(() => this.loadphones());
  }

  onCancel() {
    this.editing = false;
  }
}
