import { AddHypenPipe } from './add-hypen.pipe';

describe('AddHypenPipe', () => {
  it('create an instance', () => {
    const pipe = new AddHypenPipe();
    expect(pipe).toBeTruthy();
  });
});
