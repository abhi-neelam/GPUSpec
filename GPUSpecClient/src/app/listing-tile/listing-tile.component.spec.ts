import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListingTileComponent } from './listing-tile.component';

describe('ListingTileComponent', () => {
  let component: ListingTileComponent;
  let fixture: ComponentFixture<ListingTileComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ListingTileComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ListingTileComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
