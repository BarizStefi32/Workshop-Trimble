import { AddPipePipe } from './add-pipe.pipe';

describe('AddPipePipe', () => {
  it('create an instance', () => {
    const pipe = new AddPipePipe();
    expect(pipe).toBeTruthy();
  });
});
