import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GpulistingPageComponent } from './gpulisting-page.component';

describe('GpulistingPageComponent', () => {
  let component: GpulistingPageComponent;
  let fixture: ComponentFixture<GpulistingPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [GpulistingPageComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(GpulistingPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
