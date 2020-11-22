import { Component } from '@angular/core';
import { CreateGroupResponseDTO } from '../core/api.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {

  group: CreateGroupResponseDTO;

  onGroupCreated(group: CreateGroupResponseDTO){
    this.group = group;
  }
}

