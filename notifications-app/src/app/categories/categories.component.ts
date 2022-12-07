import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { Category } from '../category';

@Component({
  selector: 'app-categories',
  templateUrl: './categories.component.html',
  styleUrls: ['./categories.component.scss']
})
export class CategoriesComponent implements OnInit {

  categories:string[] = Object.keys(Category);
  @Output() selectedCategoryEmitter = new EventEmitter<string>();

  constructor() { }

  ngOnInit(): void {
  }

  onClick(category:string) {
    this.selectedCategoryEmitter.emit(category);
  }

}
