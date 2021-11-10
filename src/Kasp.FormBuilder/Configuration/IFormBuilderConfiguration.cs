namespace Kasp.FormBuilder.Configuration; 

public interface IFormBuilderConfiguration<TModel> {
	void Configure(IConfigureBuilder<TModel> builder);
}


public class MyTestDto {
	public string Title { get; set; }
	public bool IsEnable { get; set; }
}

// public class MyTestDtoFormConfiguration : IFormBuilderConfiguration<MyTestDto> {
// 	public void Configure(IConfigureBuilder<MyTestDto> builder) {
// 		builder.WithLinearLayout(linear => {
// 			linear
// 				.SetComponentValue(x => x.Orientation, LinearLayoutOrientation.Horizontal)
// 				.SetName("asdasdsad");
//
// 			linear.SetOrientation(LinearLayoutOrientation.Horizontal);
//
// 			linear.AddComponent<NumberFieldComponent>(x => x.Title, TitleBuilderAction);
// 			linear.AddComponent<LinearLayoutComponent>(x => x.Title, configuration => {
// 				configuration.
// 			});
// 		});
// 	}
//
// 	private void TitleBuilderAction(IComponentConfiguration<NumberFieldComponent, MyTestDto> component) {
// 		component.SetName()
// 	}
// }